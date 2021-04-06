package me.derangedsenators.copsandrobbers;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import com.unity3d.player.R;
import io.noties.markwon.Markwon;
import org.w3c.dom.Text;

/**
 * This is the fragment that can display the changelog
 * @author Hanzalah Ravat
 */
public class ChangelogFragment extends Fragment {

    public static final String TAG = "CHANGELOG_FRAGMENT";
    private final String changelog;

    public ChangelogFragment(String changelog){
        this.changelog = changelog;
    }

    public View onCreateView(
            @NonNull LayoutInflater inflater,
            ViewGroup container,
            Bundle savedInstanceState
            ){
        System.out.println("Creating View Fragment");
        View root = inflater.inflate(R.layout.changelog_view,container,false);
        final Markwon markwon = Markwon.create(getContext());
        final TextView changelogView = root.findViewById(R.id.changelogTextView);
        markwon.setMarkdown(changelogView,changelog);
        return root;
    }
}
