package hr.fer.oo.ednevnik.main;

import android.app.ProgressDialog;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;
import android.widget.Toast;

import java.text.SimpleDateFormat;
import java.util.List;
import java.util.Locale;

import butterknife.BindView;
import butterknife.ButterKnife;
import hr.fer.oo.ednevnik.MyApplication;
import hr.fer.oo.ednevnik.R;
import hr.fer.oo.ednevnik.Utils;
import hr.fer.oo.ednevnik.model.Absence;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class AbsenceFragment extends Fragment {

    @BindView(R.id.table_main)
    TableLayout tableLayout;

    List<Absence> absences;

    ProgressDialog progressDialog;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        progressDialog = new ProgressDialog(getActivity());
        progressDialog.setIndeterminate(true);
        progressDialog.setMessage("Dohvaćam podatke...");
        progressDialog.show();

        final FragmentActivity fragmentActivity = getActivity();

        Call<List<Absence>> call = Utils.getRestApi().getAbsences(MyApplication.getToken().getAccess_token());
        call.enqueue(new Callback<List<Absence>>() {
            @Override
            public void onResponse(Call<List<Absence>> call, Response<List<Absence>> response) {
                progressDialog.hide();

                if(response.body() != null){
                    absences = response.body();
                    setData(fragmentActivity);
                }else{
                    Toast.makeText(getActivity(), "Greška!", Toast.LENGTH_LONG).show();
                }
            }

            @Override
            public void onFailure(Call<List<Absence>> call, Throwable t) {
                progressDialog.hide();

                Toast.makeText(getActivity(), "Greška!", Toast.LENGTH_LONG).show();
            }
        });
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_absence, container, false);
        ButterKnife.bind(this, view);

        return view;
    }

    private void setData(FragmentActivity fragmentActivity){

        SimpleDateFormat formatter = new SimpleDateFormat("dd.MM.yyyy", Locale.UK);

        for (Absence absence : absences) {
            TableRow tbrow = new TableRow(fragmentActivity);

            TextView t1v = new TextView(fragmentActivity);
            t1v.setText(formatter.format(absence.getDate()));
            tbrow.addView(t1v);

            TextView t2v = new TextView(fragmentActivity);
            t2v.setText(absence.getSubject().getName());
            tbrow.addView(t2v);

            TextView t3v = new TextView(fragmentActivity);
            t3v.setText(absence.getReason());
            tbrow.addView(t3v);

            TextView t4v = new TextView(fragmentActivity);
            t4v.setText(absence.getValidity() ? "DA" : "NE");
            tbrow.addView(t4v);

            tableLayout.addView(tbrow);
        }

    }
}
