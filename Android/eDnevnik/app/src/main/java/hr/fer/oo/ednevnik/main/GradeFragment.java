package hr.fer.oo.ednevnik.main;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import java.util.List;

import hr.fer.oo.ednevnik.MyApplication;
import hr.fer.oo.ednevnik.R;
import hr.fer.oo.ednevnik.Utils;
import hr.fer.oo.ednevnik.adapters.MyGradeRecyclerViewAdapter;
import hr.fer.oo.ednevnik.model.Grade;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class GradeFragment extends Fragment {

    List<Grade> grades;

    RecyclerView recyclerView;

    ProgressDialog progressDialog;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        progressDialog = new ProgressDialog(getActivity());
        progressDialog.setIndeterminate(true);
        progressDialog.setMessage("Dohvaćam podatke...");
        progressDialog.show();

        Call<List<Grade>> call = Utils.getRestApi().getGrades(MyApplication.getToken().getAccess_token());
        call.enqueue(new Callback<List<Grade>>() {
            @Override
            public void onResponse(Call<List<Grade>> call, Response<List<Grade>> response) {
                progressDialog.hide();

                if (response.body() != null) {
                    grades = response.body();
                    setData();
                } else {
                    Toast.makeText(getActivity(), "Greška!", Toast.LENGTH_LONG).show();
                }
            }

            @Override
            public void onFailure(Call<List<Grade>> call, Throwable t) {
                progressDialog.hide();

                Toast.makeText(getActivity(), "Greška!", Toast.LENGTH_LONG).show();
            }
        });
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_grade_list, container, false);

        if (view instanceof RecyclerView) {
            Context context = view.getContext();
            recyclerView = (RecyclerView) view;
            recyclerView.setLayoutManager(new LinearLayoutManager(context));
        }
        return view;
    }

    private void setData() {
        recyclerView.setAdapter(new MyGradeRecyclerViewAdapter(grades));
    }
}
