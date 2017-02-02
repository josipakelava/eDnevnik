package hr.fer.oo.ednevnik.main;

import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.view.Gravity;
import android.view.View;
import android.widget.Button;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;
import android.widget.Toast;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Locale;

import butterknife.BindView;
import butterknife.ButterKnife;
import hr.fer.oo.ednevnik.MyApplication;
import hr.fer.oo.ednevnik.R;
import hr.fer.oo.ednevnik.Utils;
import hr.fer.oo.ednevnik.model.Category;
import hr.fer.oo.ednevnik.model.Cmn;
import hr.fer.oo.ednevnik.model.Mark;
import hr.fer.oo.ednevnik.model.Note;
import hr.fer.oo.ednevnik.sendData.AddMarkActivity;
import hr.fer.oo.ednevnik.sendData.AddNoteActivity;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MarksProfActivity extends AppCompatActivity {

    @BindView(R.id.table_marks)
    TableLayout tableLayout;

    @BindView(R.id.table_notes)
    TableLayout tableNotesLayout;

    @BindView(R.id.add_mark)
    Button newMarkBtn;

    @BindView(R.id.add_note)
    Button newNoteBtn;

    @BindView(R.id.add_absence)
    Button newAbsenceBtn;

    ProgressDialog progressDialog;

    private static String studentid = "0";
    private static String gradeId = StudentsActivity.getGradeId();
    private static String subjectId = StudentsActivity.getSubjectId();
    private static String title = StudentsActivity.getSubjectName();

    private Cmn cmn;

    private static List<Mark> marks;
    private static List<Category> categories;
    private static List<Note> notes;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_marks_prof);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        ButterKnife.bind(this);

        Bundle extras = getIntent().getExtras();
        if (extras != null) {
            studentid = extras.getString("STUDENT_ID");
            setTitle(title);
        }

        progressDialog = new ProgressDialog(this);
        progressDialog.setIndeterminate(true);
        progressDialog.setMessage("Dohvaćam podatke...");
        progressDialog.show();

        final AppCompatActivity activity = this;

        Call<Cmn> call = Utils.getRestApi().getCmnForStudent(MyApplication.getToken().getAccess_token(), Integer.valueOf(gradeId), Integer.valueOf(subjectId), Integer.valueOf(studentid));
        call.enqueue(new Callback<Cmn>() {
            @Override
            public void onResponse(Call<Cmn> call, Response<Cmn> response) {
                progressDialog.hide();

                if (response.body() != null) {
                    cmn = response.body();
                    categories = cmn.getCategories();
                    marks = cmn.getMarks();
                    notes = cmn.getNotes();
                    setData();
                } else {
                    Toast.makeText(activity, "Greška!", Toast.LENGTH_LONG).show();
                }
            }

            @Override
            public void onFailure(Call<Cmn> call, Throwable t) {
                progressDialog.hide();

                Toast.makeText(activity, "Greška!", Toast.LENGTH_LONG).show();
            }
        });

        newMarkBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(activity, AddMarkActivity.class);
                activity.startActivity(intent);
            }
        });

        newNoteBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(activity, AddNoteActivity.class);
                activity.startActivity(intent);
            }
        });

        newAbsenceBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                AlertDialog.Builder builder1 = new AlertDialog.Builder(activity, R.style.EditTextCustom);
                builder1.setTitle("Izostanak");
                builder1.setMessage("Jeste li sigurni da želite dodati izostanak učeniku?");
                builder1.setCancelable(true);

                builder1.setPositiveButton(R.string.yes, new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {

                                progressDialog = new ProgressDialog(activity);
                                progressDialog.setIndeterminate(true);
                                progressDialog.setMessage("Šaljem izostanak...");
                                progressDialog.show();

                                Date date = new Date();
                                SimpleDateFormat postFormater = new SimpleDateFormat("dd.MM.yyyy");
                                String dateStr = postFormater.format(date);

                                String reason = "";
                                Call<Boolean> call = Utils.getRestApi().addAbsence(studentid, subjectId, dateStr, reason);
                                call.enqueue(new Callback<Boolean>() {
                                    @Override
                                    public void onResponse(Call<Boolean> call, Response<Boolean> response) {
                                        progressDialog.hide();

                                        if (response.body() != null && response.body()) {
                                            Toast.makeText(activity, "Izostanak spremljena", Toast.LENGTH_LONG).show();
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
                                dialog.cancel();
                            }
                        });

                builder1.setNegativeButton(R.string.no, new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                dialog.cancel();
                            }
                        });

                AlertDialog alert11 = builder1.create();
                alert11.show();
            }
        });

    }

    private void setData() {

        SimpleDateFormat formatter = new SimpleDateFormat("dd.MM.yyyy", Locale.UK);

        for (final Category category : categories) {

            List<Mark> marksInCategory = new ArrayList<>();

            for (Mark mark : marks) {
                if (mark.getCategoryId().equals(category.getId())) {
                    marksInCategory.add(mark);
                }
            }

            TableRow tbrow = new TableRow(this);

            TextView categoryTV = new TextView(this);
            categoryTV.setText(category.getName());
            categoryTV.setPadding(5, 0, 0, 0);
            categoryTV.setBackgroundResource(R.drawable.border_for_cell);
            tbrow.addView(categoryTV);

            for (int i = 9; i != 7; i++) {
                if (i > 12) {
                    i = 1;
                }
                TextView tv = new TextView(this);
                Mark mark = null;
                for (Mark markItem : marksInCategory) {
                    if (markItem.getDate().getMonth() + 1 == i) {
                        mark = markItem;
                    }
                }
                if (mark != null) {
                    tv.setText(String.valueOf(mark.getMark()));
                } else {
                    tv.setText("");
                }
                tv.setGravity(Gravity.CENTER);
                tv.setBackgroundResource(R.drawable.border_for_cell);
                tbrow.addView(tv);

            }

            tableLayout.addView(tbrow);
        }


        for (Note note : notes) {
            TableRow noteRow = new TableRow(this);

            TextView noteDateTV = new TextView(this);
            noteDateTV.setText(formatter.format(note.getDate()));
            noteDateTV.setPadding(5, 0, 0, 0);
            noteDateTV.setBackgroundResource(R.drawable.border_for_cell);

            TextView noteNoteTV = new TextView(this);
            noteNoteTV.setText(note.getNote());
            noteNoteTV.setPadding(5, 0, 0, 0);
            noteNoteTV.setBackgroundResource(R.drawable.border_for_cell);

            noteRow.addView(noteDateTV);
            noteRow.addView(noteNoteTV);
            tableNotesLayout.addView(noteRow);
        }
    }

    public static String getStudentid() {
        return studentid;
    }

    public static String getGradeId() {
        return gradeId;
    }

    public static String getSubjectId() {
        return subjectId;
    }

    public static List<Mark> getMarks() {
        return marks;
    }

    public static List<Category> getCategories() {
        return categories;
    }

    public static List<Note> getNotes() {
        return notes;
    }

    @Override
    public boolean onSupportNavigateUp(){
        finish();
        return true;
    }
}
