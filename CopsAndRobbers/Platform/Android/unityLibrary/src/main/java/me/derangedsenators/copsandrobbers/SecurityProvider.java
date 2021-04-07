package me.derangedsenators.copsandrobbers;

import android.content.Context;
import android.util.Log;
import com.scottyab.rootbeer.RootBeer;
import com.scottyab.safetynet.SafetyNetHelper;
import com.unity3d.player.BuildConfig;

import java.util.LinkedList;
import java.util.List;

/**
 * This class provides a "Security Approval" for the App to Operate correctly
 * @author Hanzalah Ravat
 */
public final class SecurityProvider {

    public static final String TAG = "SECURITY_CHECK_PROVIDER";
    private final boolean rootCheck;
    private boolean mCtsBasic;
    private boolean mCtsProfileMatch;
    private boolean safetyNetCheckDone;


    public final boolean getCTSBasicIntegrity(){return mCtsBasic;}
    public final boolean getCTSProfileMatch(){return mCtsProfileMatch;}
    public final boolean getRootStatus(){return rootCheck;}
    public final boolean isSafetyNetCheckDone(){return safetyNetCheckDone;}
    private final List<SafetyNetListener> safetyNetListeners;
    private final Context context;
    private static final String API_KEY = BuildConfig.DEVICE_VERITY_API;
    private static SecurityProvider instance;

    public static SecurityProvider getProvider(Context context){
        if(instance == null){
            instance = new SecurityProvider(context);
        }
        return instance;
    }


    private SecurityProvider(Context context){
        this.context = context;
        safetyNetListeners = new LinkedList<>();
        final RootBeer rootCheck = new RootBeer(context);
        this.rootCheck = rootCheck.isRooted();

        final SafetyNetHelper safetyNetHelper = new SafetyNetHelper(API_KEY);

        safetyNetHelper.requestTest(context, new SafetyNetHelper.SafetyNetWrapperCallback() {
            @Override
            public void error(int errorCode, String errorMessage) {
                Log.e(TAG,errorMessage);
            }

            @Override
            public void success(boolean ctsProfileMatch, boolean basicIntegrity) {
                mCtsProfileMatch = ctsProfileMatch;
                mCtsBasic = basicIntegrity;
                safetyNetCheckDone = true;
                Log.println(Log.DEBUG,TAG,"Safetynet check success. Result:" + ctsProfileMatch + " " + basicIntegrity);
                for (SafetyNetListener l:
                     safetyNetListeners) {
                    l.onChecksComplete();
                }
            }
        });
    }
    public void addListener(SafetyNetListener l){
        safetyNetListeners.add(l);
    }
    public interface SafetyNetListener{

        void onChecksComplete();
    }


}
