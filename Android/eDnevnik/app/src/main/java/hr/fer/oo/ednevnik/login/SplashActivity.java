package hr.fer.oo.ednevnik.login;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.Window;

import hr.fer.oo.ednevnik.MyApplication;
import hr.fer.oo.ednevnik.R;
import hr.fer.oo.ednevnik.main.MainActivity;
import hr.fer.oo.ednevnik.model.Token;

public class SplashActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        this.requestWindowFeature(Window.FEATURE_NO_TITLE);
        setContentView(R.layout.activity_splash);

        SharedPreferences sharedPref = getSharedPreferences("data", Context.MODE_PRIVATE);
        String token = sharedPref.getString("TOKEN", "");
        String role = sharedPref.getString("ROLE", "");

        Intent intent;

        if(token.isEmpty() || role.isEmpty()){
            intent = new Intent(this, LoginActivity.class);
        }else{
            MyApplication.setToken(new Token(token));
            MyApplication.setRole(role);
            intent = new Intent(this, MainActivity.class);
        }
        startActivity(intent);
        finish();
    }
}
