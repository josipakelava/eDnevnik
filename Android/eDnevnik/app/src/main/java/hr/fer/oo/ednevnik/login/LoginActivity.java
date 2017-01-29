package hr.fer.oo.ednevnik.login;

import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Typeface;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.view.Window;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import butterknife.BindView;
import butterknife.ButterKnife;
import hr.fer.oo.ednevnik.MyApplication;
import hr.fer.oo.ednevnik.R;
import hr.fer.oo.ednevnik.Utils;
import hr.fer.oo.ednevnik.main.MainActivity;
import hr.fer.oo.ednevnik.model.Token;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class LoginActivity extends AppCompatActivity {

    @BindView(R.id.e_dnevnik_login)
    TextView eDnevnikText;

    @BindView(R.id.login_btn)
    Button loginBtn;

    @BindView(R.id.login_username)
    EditText username;

    @BindView(R.id.login_password)
    EditText password;

    @BindView(R.id.role)
    Spinner roleSpinner;

    private ProgressDialog progressDialog;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        this.requestWindowFeature(Window.FEATURE_NO_TITLE);
        setContentView(R.layout.activity_login);
        ButterKnife.bind(this);

        Typeface tf = Typeface.createFromAsset(getAssets(), "fonts/GochiHand.ttf");
        eDnevnikText.setTypeface(tf);

        progressDialog = new ProgressDialog(this);
        progressDialog.setIndeterminate(true);
        progressDialog.setMessage("Prijavljujem se...");

        final Context context = this;
        loginBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                progressDialog.show();

                String usernameString = username.getText().toString();
                String passwordString = password.getText().toString();
                String role = roleSpinner.getSelectedItem().toString();

                role = role.replace("č", "c");
                final String finalRole = role;

                Call<Token> call = Utils.getRestApi().login(usernameString, passwordString, role);
                call.enqueue(new Callback<Token>() {
                    @Override
                    public void onResponse(Call<Token> call, Response<Token> response) {
                        progressDialog.hide();
                        if (response.body() != null) {
                            MyApplication.setToken(response.body());
                            MyApplication.setRole(finalRole);

                            SharedPreferences sharedPref = getSharedPreferences("data", Context.MODE_PRIVATE);
                            SharedPreferences.Editor editor = sharedPref.edit();
                            String token = response.body().getAccess_token();
                            editor.putString("TOKEN", token);
                            editor.putString("ROLE", finalRole);
                            editor.apply();

                            Intent i = new Intent(context, MainActivity.class);
                            startActivity(i);
                            finish();
                        } else {
                            Toast.makeText(context, "Neuspješna prijava", Toast.LENGTH_LONG).show();
                        }
                    }

                    @Override
                    public void onFailure(Call<Token> call, Throwable t) {
                        progressDialog.hide();
                        Toast.makeText(context, "Neuspješna prijava", Toast.LENGTH_LONG).show();
                    }
                });
            }
        });
    }
}
