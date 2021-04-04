package me.derangedsenators.copsandrobbers;

import android.Manifest;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;
import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.cardview.widget.CardView;
import androidx.core.app.ActivityCompat;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.google.android.material.snackbar.Snackbar;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.unity3d.player.R;
import com.unity3d.player.UnityPlayerActivity;
import org.w3c.dom.Text;

import java.util.Locale;

/**
 * This is a Custom Launcher Activity for Cops And Robbers. Here, the app performs many tests such as Version Checking, Root Checks and SafetyNet Attestation
 * @author Hanzalah Ravat
 * @since 3.1.0
 */
public class MainActivity extends Activity {

    private Button mInstallButton;
    private Context context;
    private RequestQueue volleyQueue;
    private String mVersion;
    private ReleaseAPIResponse apiResponse;
    public static final String API_URL = "https://api.github.com/repos/DerangedSenators/copsandrobbers/releases/latest";
    public static final int PERMISSION_REQUEST_STORAGE = 0;

    private DownloadController mDownloadController;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        context = getApplicationContext();
        try{
            mVersion = "v" + context.getPackageManager()
                    .getPackageInfo(context.getPackageName(), 0).versionName;
        } catch (PackageManager.NameNotFoundException e) {
            e.printStackTrace();
        }
        apiRequest(new responseHandler());


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
        super.findViewById(R.id.downloadInstallButton).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                checkPermissionAndDownload();
            }
        });
        if(apiResponse.getTag_name().equals(mVersion)){
            CardView versionView = super.findViewById(R.id.versionCardView);
            versionView.setVisibility(0);
        }else {
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

    private class responseHandler implements ApiResponseListener{


        @Override
        public void onAPIResponse(ReleaseAPIResponse response) {
            if(response.getTag_name().equals(mVersion))
                startGame();
            else{
                // Don't start and update view
                apiResponse = response;
                onLaunchFail();
            }
        }

        @Override
        public void onError(Exception exception) {

       }
    }
}