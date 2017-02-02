package hr.fer.oo.ednevnik.sendData;

import android.app.Activity;
import android.app.ProgressDialog;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import java.text.SimpleDateFormat;
import java.util.Date;

import butterknife.BindView;
import butterknife.ButterKnife;
import hr.fer.oo.ednevnik.R;
import hr.fer.oo.ednevnik.Utils;
import hr.fer.oo.ednevnik.main.MarksProfActivity;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class AddNoteActivity extends AppCompatActivity {

    private String studentid = MarksProfActivity.getStudentid();
    private String subjectId = MarksProfActivity.getSubjectId();

    @BindView(R.id.add_new_note_ok)
    Button okButton;

    @BindView(R.id.add_new_note_cancle)
    Button cancleButton;

    @BindView(R.id.add_note_note)
    EditText noteET;

    ProgressDialog progressDialog;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_note);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        ButterKnife.bind(this);
        setTitle("Dodaj bilješku");
        final Activity activity = this;

        okButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                progressDialog = new ProgressDialog(activity);
                progressDialog.setIndeterminate(true);
                progressDialog.setMessage("Šaljem bilješku...");
                progressDialog.show();

                String note = noteET.getText().toString();
                Date date = new Date();

                SimpleDateFormat postFormater = new SimpleDateFormat("dd.MM.yyyy");
                String dateStr = postFormater.format(date);

                Call<Boolean> call = Utils.getRestApi().addNote(studentid, subjectId, dateStr, note);
                call.enqueue(new Callback<Boolean>() {
                    @Override
                    public void onResponse(Call<Boolean> call, Response<Boolean> response) {
                        progressDialog.hide();

                        if (response.body() != null && response.body()) {
                            Toast.makeText(activity, "Bilješka spremljena", Toast.LENGTH_LONG).show();
                            activity.finish();
                        } else {
                            Toast.makeText(activity, "Greška!", Toast.LENGTH_LONG).show();
                        }
                    }

                    @Override
                    public void onFailure(Call<Boolean> call, Throwable t) {
                        progressDialog.hide();

                        Toast.makeText(activity, "Greška!", Toast.LENGTH_LONG).show();
                    }
                });
            }
        });

        cancleButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                activity.finish();
            }
        });

    }

    @Override
    public boolean onSupportNavigateUp(){
        finish();
        return true;
    }
}
