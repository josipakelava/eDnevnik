package hr.fer.oo.ednevnik.main;

import android.app.ProgressDialog;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.Toast;

import java.text.SimpleDateFormat;
import java.util.Locale;

import butterknife.BindView;
import butterknife.ButterKnife;
import hr.fer.oo.ednevnik.MyApplication;
import hr.fer.oo.ednevnik.R;
import hr.fer.oo.ednevnik.Utils;
import hr.fer.oo.ednevnik.model.User;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ProfilFragment extends Fragment {

    private User mUser;

    @BindView(R.id.profile_first_name)
    TextView firstNameTextView;

    @BindView(R.id.profile_last_name)
    TextView lastNameTextView;

    @BindView(R.id.profile_birth_date)
    TextView birthdateTextView;

    @BindView(R.id.profil_address)
    TextView addressTextView;

    @BindView(R.id.profile_oib)
    TextView oibTextView;

    @BindView(R.id.profile_mail)
    TextView mailTextView;

    @BindView(R.id.profile_city)
    TextView cityTextView;

    ProgressDialog progressDialog;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        progressDialog = new ProgressDialog(getActivity());
        progressDialog.setIndeterminate(true);
        progressDialog.setMessage("Dohvaćam podatke...");
        progressDialog.show();

        if (MyApplication.getRole().equals("Ucenik")) {
            Call<User> call = Utils.getRestApi().getProfile(MyApplication.getToken().getAccess_token());
            call.enqueue(new Callback<User>() {
                @Override
                public void onResponse(Call<User> call, Response<User> response) {
                    progressDialog.hide();

                    if (response.body() != null) {
                        mUser = response.body();
                        setData();
                    } else {
                        Toast.makeText(getActivity(), "Greška!", Toast.LENGTH_LONG).show();
                    }
                }

                @Override
                public void onFailure(Call<User> call, Throwable t) {
                    progressDialog.hide();

                    Toast.makeText(getActivity(), "Greška!", Toast.LENGTH_LONG).show();
                }
            });
        } else {
            Call<User> call = Utils.getRestApi().getProfileProf(MyApplication.getToken().getAccess_token());
            call.enqueue(new Callback<User>() {
                @Override
                public void onResponse(Call<User> call, Response<User> response) {
                    progressDialog.hide();

                    if (response.body() != null) {
                        mUser = response.body();
                        setData();
                    } else {
                        Toast.makeText(getActivity(), "Greška!", Toast.LENGTH_LONG).show();
                    }
                }

                @Override
                public void onFailure(Call<User> call, Throwable t) {
                    progressDialog.hide();

                    Toast.makeText(getActivity(), "Greška!", Toast.LENGTH_LONG).show();
                }
            });
        }

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_profil, container, false);
        ButterKnife.bind(this, view);

        return view;
    }

    private void setData() {
        SimpleDateFormat formatter = new SimpleDateFormat("dd.MM.yyyy", Locale.UK);

        firstNameTextView.setText(mUser.getFirstName());
        lastNameTextView.setText(mUser.getLastName());
        birthdateTextView.setText(formatter.format(mUser.getBirthDate()));
        addressTextView.setText(mUser.getAddress());
        oibTextView.setText(mUser.getOib());
        cityTextView.setText(mUser.getCity().getName());
        mailTextView.setText(mUser.getMail());
    }
}
