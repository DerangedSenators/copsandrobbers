package me.derangedsenators.copsandrobbers;

import android.app.ActionBar;
import android.app.Activity;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.fragment.app.Fragment;
import com.unity3d.player.R;
import io.noties.markwon.AbstractMarkwonPlugin;
import io.noties.markwon.Markwon;
import io.noties.markwon.core.MarkwonTheme;
import org.w3c.dom.Text;

/**
 * This is the fragment that can display the changelog
 * @author Hanzalah Ravat
 */
public class ChangelogActivity extends AppCompatActivity {

    public static final String TAG = "CHANGELOG_FRAGMENT";


    @Override
    protected void onCreate(
            Bundle savedInstanceState
            ){
        super.onCreate(savedInstanceState);
        System.out.println("Creating View Fragment");
        setContentView(R.layout.changelog_view);
        final String changelog = getIntent().getStringExtra("changelog");
        final Markwon markwon = Markwon.builder(getApplicationContext())
                .usePlugin(new AbstractMarkwonPlugin() {
                    @Override
                    public void configureTheme(@NonNull MarkwonTheme.Builder builder) {
                        builder
                                .headingBreakHeight(0);
                    }
                })
                .build();
        final TextView changelogView = findViewById(R.id.changelogTextView);
        markwon.setMarkdown(changelogView,changelog);

    }


    public void onBackClick(View view) {
        super.onBackPressed();
    }
}
