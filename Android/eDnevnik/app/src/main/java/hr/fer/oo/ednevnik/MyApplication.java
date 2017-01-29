package hr.fer.oo.ednevnik;

import android.app.Application;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import hr.fer.oo.ednevnik.model.Token;
import okhttp3.OkHttpClient;
import okhttp3.logging.HttpLoggingInterceptor;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

/**
 * Created by luka0 on 18.1.2017..
 */

public class MyApplication extends Application {

    private static Token token;
    private static String role;

    @Override
    public void onCreate() {
        super.onCreate();

        HttpLoggingInterceptor interceptor = new HttpLoggingInterceptor();
        interceptor.setLevel(HttpLoggingInterceptor.Level.BODY);
        OkHttpClient client = new OkHttpClient.Builder().addInterceptor(interceptor).build();

        Gson gson = new GsonBuilder()
                .setDateFormat("yyyy-MM-dd'T'HH:mm:ss")
                .create();

        Retrofit retrofit = new Retrofit.Builder()
                .baseUrl(Utils.getADDRES())
                .client(client)
                .addConverterFactory(GsonConverterFactory.create(gson))
                .build();

        Utils.setRestApi(retrofit.create(RestApi.class));

    }

    public static Token getToken() {
        return token;
    }

    public static void setToken(Token token) {
        MyApplication.token = token;
    }

    public static String getRole() {
        return role;
    }

    public static void setRole(String role) {
        MyApplication.role = role;
    }
}
