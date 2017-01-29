package hr.fer.oo.ednevnik.main;

import android.app.ProgressDialog;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.Gravity;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;
import android.widget.Toast;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
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
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MarksActivity extends AppCompatActivity {

    @BindView(R.id.table_marks)
    TableLayout tableLayout;

    @BindView(R.id.table_notes)
    TableLayout tableNotesLayout;

    ProgressDialog progressDialog;

    private String id = "0";
    private String title = "";

    private Cmn cmn;

    private List<Mark> marks;
    private List<Category> categories;
    private List<Note> notes;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_marks);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        ButterKnife.bind(this);


        Bundle extras = getIntent().getExtras();
        if (extras != null) {
            id = extras.getString("ID");
            title = extras.getString("TITLE");
            setTitle(title);
        }

        progressDialog = new ProgressDialog(this);
        progressDialog.setIndeterminate(true);
        progressDialog.setMessage("Dohvaćam podatke...");
        progressDialog.show();

        final AppCompatActivity activity = this;

        Call<Cmn> call = Utils.getRestApi().getCmn(MyApplication.getToken().getAccess_token(), Integer.parseInt(id));
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

    @Override
    public boolean onSupportNavigateUp() {
        finish();
        return true;
    }
}
