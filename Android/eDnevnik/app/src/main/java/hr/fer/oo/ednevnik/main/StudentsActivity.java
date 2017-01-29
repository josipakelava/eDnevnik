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
import hr.fer.oo.ednevnik.adapters.MyTeacherStudentRecyclerViewAdapter;
import hr.fer.oo.ednevnik.model.Student;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class StudentsActivity extends AppCompatActivity {

    private RecyclerView recyclerView;
    private List<Student> students = new ArrayList<>();
    private ProgressDialog progressDialog;

    private static String subjectId = "0";
    private static String gradeId = SubjectActivity.getGradeId();
    private static String subjectName = "";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_students);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        Bundle extras = getIntent().getExtras();
        if (extras != null) {
            subjectId = extras.getString("SUBJECT_ID");
            subjectName = extras.getString("SUBJECT_NAME");
        }

        final AppCompatActivity activity = this;

        progressDialog = new ProgressDialog(this);
        progressDialog.setIndeterminate(true);
        progressDialog.setMessage("Dohvaćam podatke...");
        progressDialog.show();

        Call<List<Student>> call = Utils.getRestApi().getStudentsForSubject(MyApplication.getToken().getAccess_token(), Integer.valueOf(gradeId), Integer.valueOf(subjectId));
        call.enqueue(new Callback<List<Student>>() {
            @Override
            public void onResponse(Call<List<Student>> call, Response<List<Student>> response) {
                progressDialog.hide();

                if (response.body() != null) {
                    students = response.body();
                    setData();
                } else {
                    Toast.makeText(activity, "Greška!", Toast.LENGTH_LONG).show();
                }
            }

            @Override
            public void onFailure(Call<List<Student>> call, Throwable t) {
                progressDialog.hide();

                Toast.makeText(activity, "Greška!", Toast.LENGTH_LONG).show();
            }
        });

        recyclerView = (RecyclerView) findViewById(R.id.recycler_view_students);

        RecyclerView.LayoutManager mLayoutManager = new LinearLayoutManager(getApplicationContext());
        recyclerView.setLayoutManager(mLayoutManager);
        recyclerView.setItemAnimator(new DefaultItemAnimator());
    }


    private void setData() {
        recyclerView.setAdapter(new MyTeacherStudentRecyclerViewAdapter(students));
    }

    @Override
    public boolean onSupportNavigateUp(){
        finish();
        return true;
    }

    public static String getSubjectId() {
        return subjectId;
    }

    public static String getGradeId() {
        return gradeId;
    }

    public static String getSubjectName() {
        return subjectName;
    }
}
