package hr.fer.oo.ednevnik.main;

import android.app.ProgressDialog;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.DefaultItemAnimator;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

import hr.fer.oo.ednevnik.MyApplication;
import hr.fer.oo.ednevnik.R;
import hr.fer.oo.ednevnik.Utils;
import hr.fer.oo.ednevnik.adapters.MyTeacherSubjectRecyclerViewAdapter;
import hr.fer.oo.ednevnik.model.Subject;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class SubjectActivity extends AppCompatActivity {

    private RecyclerView recyclerView;
    private List<Subject> subjects = new ArrayList<>();
    private ProgressDialog progressDialog;

    private static String gradeId = "0";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_subject);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        Bundle extras = getIntent().getExtras();
        if (extras != null) {
            gradeId = extras.getString("GRADE_ID");
        }

        final AppCompatActivity activity = this;

        progressDialog = new ProgressDialog(this);
        progressDialog.setIndeterminate(true);
        progressDialog.setMessage("Dohvaćam podatke...");
        progressDialog.show();

        Call<List<Subject>> call = Utils.getRestApi().getSubjectsForGrade(MyApplication.getToken().getAccess_token(), Integer.valueOf(gradeId));
        call.enqueue(new Callback<List<Subject>>() {
            @Override
            public void onResponse(Call<List<Subject>> call, Response<List<Subject>> response) {
                progressDialog.hide();

                if (response.body() != null) {
                    subjects = response.body();
                    setData();
                } else {
                    Toast.makeText(activity, "Greška!", Toast.LENGTH_LONG).show();
                }
            }

            @Override
            public void onFailure(Call<List<Subject>> call, Throwable t) {
                progressDialog.hide();

                Toast.makeText(activity, "Greška!", Toast.LENGTH_LONG).show();
            }
        });

        recyclerView = (RecyclerView) findViewById(R.id.recycler_view_subjects);

        RecyclerView.LayoutManager mLayoutManager = new LinearLayoutManager(getApplicationContext());
        recyclerView.setLayoutManager(mLayoutManager);
        recyclerView.setItemAnimator(new DefaultItemAnimator());
    }

    private void setData() {
        recyclerView.setAdapter(new MyTeacherSubjectRecyclerViewAdapter(subjects));
    }

    @Override
    public boolean onSupportNavigateUp(){
        finish();
        return true;
    }

    public static String getGradeId() {
        return gradeId;
    }
}
