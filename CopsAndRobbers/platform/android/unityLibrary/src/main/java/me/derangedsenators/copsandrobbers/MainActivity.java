package me.derangedsenators.copsandrobbers;

import android.Manifest;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;
import androidx.annotation.NonNull;
import androidx.cardview.widget.CardView;
import androidx.core.app.ActivityCompat;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.unity3d.player.R;
import com.unity3d.player.UnityPlayerActivity;

/**
 * This is a Custom Launcher Activity for Cops And Robbers. Here, the app performs many tests such as Version Checking, Root Checks and SafetyNet Attestation
 * @author Hanzalah Ravat
 * @since 3.1.0
 */
public final class MainActivity extends Activity {
    public static final String TAG = "SECURE_LAUNCH_MAIN";
    private Button mInstallButton;
    private Context context;
    private RequestQueue volleyQueue;
    private String mVersion;
    private ReleaseAPIResponse apiResponse;
    public static final String API_URL = "https://api.github.com/repos/DerangedSenators/copsandrobbers/releases/latest";
    public static final int PERMISSION_REQUEST_STORAGE = 0;

    private DownloadController mDownloadController;

    private boolean versionCheckSuccess;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        context = getApplicationContext();
        SecurityProvider.getProvider(context).addListener(() -> {
            if(versionCheckSuccess && SecurityProvider.getProvider(context).getCTSBasicIntegrity() && !SecurityProvider.getProvider(context).getRootStatus()){
                startGame();
            } else{
                setRootView();
            }
        });
        try{
            mVersion = "v" + context.getPackageManager()
                    .getPackageInfo(context.getPackageName(), 0).versionName;
        } catch (PackageManager.NameNotFoundException e) {
            e.printStackTrace();
        }
        apiRequest(new ResponseHandler());

        // Get Latest Version from GitHub API using Volley
    }


    private void startGame(){
        Intent gameLaunchIntent = new Intent(MainActivity.this,UnityPlayerActivity.class);
        MainActivity.this.startActivity(gameLaunchIntent);
    }

    private void apiRequest(ApiResponseListener listener){
        if(volleyQueue == null)
            volleyQueue = Volley.newRequestQueue(context);
        StringRequest request = new StringRequest(Request.Method.GET, API_URL, response -> {
            Gson gson = new GsonBuilder().create();
            ReleaseAPIResponse releaseAPIResponse = gson.fromJson(response,ReleaseAPIResponse.class);
            listener.onAPIResponse(releaseAPIResponse);
        },
                listener::onError);
        volleyQueue.add(request);
    }

    private interface ApiResponseListener{

        void onAPIResponse(ReleaseAPIResponse response);

        void onError(Exception exception);
    }

    private void onLaunchFail(){
        setContentView(R.layout.update_view);
        super.findViewById(R.id.downloadInstallButton).setOnClickListener(view -> checkPermissionAndDownload());
        // OTA Download
        if(!apiResponse.getTag_name().equals(mVersion)){
            CardView versionView = super.findViewById(R.id.versionCardView);
            versionView.setVisibility(1);
            TextView currentVersion = super.findViewById(R.id.currentVerison);
            currentVersion.setText(mVersion);
            TextView latestVersion = super.findViewById(R.id.latestVerison);
            latestVersion.setText(apiResponse.getTag_name());

            // Set up downloader
            String downloadURL="";
            for (ReleaseAssets asset:
                 apiResponse.getAssets()) {
                if(asset.getContent_type().equals("application/vnd.android.package-archive")){
                    downloadURL = asset.getBrowser_download_url();
                    break;
                }
            }
            mDownloadController = new DownloadController(this,downloadURL);
            if(downloadURL.equals(""))
                super.findViewById(R.id.downloadInstallButton).setVisibility(0);
        }

        setRootView();
    }

    private void setRootView(){
        System.out.println("Setting Root View");
            if (SecurityProvider.getProvider(context).getRootStatus()) {
                System.out.println("Device is Rooted");
                super.findViewById(R.id.rootCheckCard).setVisibility(View.VISIBLE);
                ImageView root = super.findViewById(R.id.rootCheck);
                root.setImageResource(R.drawable.baseline_cancel_18);
            }
            if(SecurityProvider.getProvider(context).isSafetyNetCheckDone()) {
                super.findViewById(R.id.safetyNetProgress).setVisibility(View.GONE);
                super.findViewById(R.id.safetyNetSection).setVisibility(View.VISIBLE);
                if (SecurityProvider.getProvider(context).getCTSProfileMatch()) {
                    Log.println(Log.DEBUG, TAG, "CTS Profile Match is True");
                    ImageView root =

                            super.findViewById(R.id.ctsProfile);
                    root.setImageResource(R.drawable.baseline_verified_24);
                }
                if (SecurityProvider.getProvider(context).getCTSBasicIntegrity()) {
                    Log.println(Log.DEBUG, TAG, "CTS Basic Integrity is True");
                    ImageView root = super.findViewById(R.id.basicIntegrity);
                    root.setImageResource(R.drawable.baseline_verified_24);
                } else{
                    super.findViewById(R.id.rootCheckCard).setVisibility(View.VISIBLE);
                }
            }
    }


    private void checkPermissionAndDownload(){
        if(checkSelfPermission(Manifest.permission.WRITE_EXTERNAL_STORAGE) == PackageManager.PERMISSION_GRANTED){
            mDownloadController.enqueueDownload();
        } else {
            requestStoragePermission();
        }
    }

    private void requestStoragePermission(){
        ActivityCompat.requestPermissions(MainActivity.this, new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE},PERMISSION_REQUEST_STORAGE);
    }

    @Override
    public void onRequestPermissionsResult(int requestCode,
                                           @NonNull String[] permissions,
                                           @NonNull int[] grantResults)
    {
        super.onRequestPermissionsResult(requestCode,
                        permissions,
                        grantResults);
        if (requestCode == PERMISSION_REQUEST_STORAGE) {
            if (grantResults.length > 0
                    && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                Toast.makeText(MainActivity.this,
                        "Storage Permission Granted",
                        Toast.LENGTH_SHORT)
                        .show();
            }
            else {
                Toast.makeText(MainActivity.this,
                        "Storage Permission Denied",
                        Toast.LENGTH_SHORT)
                        .show();
            }
        }
    }

    private class ResponseHandler implements ApiResponseListener{

        @Override
        public void onAPIResponse(ReleaseAPIResponse response) {
            if(response.getTag_name().equals(mVersion) && SecurityProvider.getProvider(context).getCTSBasicIntegrity() && ! SecurityProvider.getProvider(context).getRootStatus())
                //startGame();
                versionCheckSuccess = true;
            else{
                // Don't start and update view
                apiResponse = response;
                onLaunchFail();
            }
        }

        @Override
        public void onError(Exception exception) {
            Log.e(TAG,"Error Getting Version Information from GitHub API");
       }
    }


}
