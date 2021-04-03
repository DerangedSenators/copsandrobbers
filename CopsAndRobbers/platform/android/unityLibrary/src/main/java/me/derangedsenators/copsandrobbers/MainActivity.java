package me.derangedsenators.copsandrobbers;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import androidx.appcompat.app.AppCompatActivity;
import com.unity3d.player.R;
import com.unity3d.player.UnityPlayerActivity;

public class MainActivity extends Activity {

    private Button mInstallButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.update_view);
        super.findViewById(R.id.downloadInstallButton).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent gameLaunchIntent = new Intent(MainActivity.this,UnityPlayerActivity.class);
                MainActivity.this.startActivity(gameLaunchIntent);
            }
        });
    }

}
