package hr.fer.oo.ednevnik.sendData;

import android.app.Activity;
import android.app.ProgressDialog;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.Toast;

import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;
import hr.fer.oo.ednevnik.R;
import hr.fer.oo.ednevnik.Utils;
import hr.fer.oo.ednevnik.main.MarksProfActivity;
import hr.fer.oo.ednevnik.model.Category;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class AddMarkActivity extends AppCompatActivity {

    private String studentid = MarksProfActivity.getStudentid();
    private String subjectId = MarksProfActivity.getSubjectId();

    private List<Category> categories = MarksProfActivity.getCategories();

    @BindView(R.id.add_mark_category_spinner)
    Spinner categorySpinner;

    @BindView(R.id.add_mark_mark_spinner)
    Spinner marksSpinner;

    @BindView(R.id.add_mark_month_spinner)
    Spinner monthSpinner;

    @BindView(R.id.add_new_mark_ok)
    Button okButton;

    @BindView(R.id.add_new_mark_cancle)
    Button cancleButton;

    ProgressDialog progressDialog;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_mark);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        ButterKnife.bind(this);
        setTitle("Dodaj ocjenu");
        final Activity activity = this;

        ArrayAdapter adapter = new ArrayAdapter(this, R.layout.spinner, categories);
        categorySpinner.setAdapter(adapter);

        okButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                progressDialog = new ProgressDialog(activity);
                progressDialog.setIndeterminate(true);
                progressDialog.setMessage("Šaljem ocjenu...");
                progressDialog.show();

                String categorId = String.valueOf(((Category)categorySpinner.getSelectedItem()).getId());
                String mark = marksSpinner.getSelectedItem().toString();
                String month = monthSpinner.getSelectedItem().toString();

                Call<Boolean> call = Utils.getRestApi().addMark(studentid, subjectId, categorId, mark, month);
                call.enqueue(new Callback<Boolean>() {
                    @Override
                    public void onResponse(Call<Boolean> call, Response<Boolean> response) {
                        progressDialog.hide();

                        if (response.body() != null && response.body()) {
                            Toast.makeText(activity, "Ocjena spremljena", Toast.LENGTH_LONG).show();
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
