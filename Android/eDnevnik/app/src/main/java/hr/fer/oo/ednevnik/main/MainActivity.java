package hr.fer.oo.ednevnik.main;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.design.widget.NavigationView;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;

import hr.fer.oo.ednevnik.MyApplication;
import hr.fer.oo.ednevnik.R;
import hr.fer.oo.ednevnik.login.LoginActivity;

public class MainActivity extends AppCompatActivity implements NavigationView.OnNavigationItemSelectedListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.setDrawerListener(toggle);
        toggle.syncState();

        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);

        Menu menu = navigationView.getMenu();
        if (MyApplication.getRole().equals("Profesor")) {
            menu.findItem(R.id.nav_subject).setVisible(false);
            menu.findItem(R.id.nav_absence).setVisible(false);
            menu.findItem(R.id.nav_my_grade).setVisible(false);
        } else {
            menu.findItem(R.id.nav_my_grade).setVisible(false);
            menu.findItem(R.id.nav_all_grades).setVisible(false);
        }


        if (savedInstanceState == null) {
            Fragment fragment = new ProfilFragment();
            FragmentManager fragmentManager = getSupportFragmentManager();
            fragmentManager.beginTransaction().replace(R.id.content_main, fragment).commit();
        }
    }

    @Override
    public void onBackPressed() {
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        if (drawer.isDrawerOpen(GravityCompat.START)) {
            drawer.closeDrawer(GravityCompat.START);
        } else {
            super.onBackPressed();
        }
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();
        Fragment fragment = null;
        FragmentManager fragmentManager = getSupportFragmentManager();

        if (id == R.id.nav_profil) {
            fragment = new ProfilFragment();
        } else if (id == R.id.nav_subject) {
            fragment = new SubjectFragment();
        } else if (id == R.id.nav_absence) {
            fragment = new AbsenceFragment();
        } else if (id == R.id.nav_all_grades) {
            fragment = new GradeFragment();
        } else if (id == R.id.nav_my_grade) {
//            fragment = new MyGradeFragment();
        } else if (id == R.id.nav_logoff) {
            SharedPreferences sharedPref = getSharedPreferences("data", Context.MODE_PRIVATE);
            SharedPreferences.Editor editor = sharedPref.edit();

            editor.putString("TOKEN", "");
            editor.putString("ROLE", "");
            editor.apply();

            Intent intent = new Intent(this, LoginActivity.class);
            startActivity(intent);
            finish();
        }
        if (fragment != null) {
            fragmentManager.beginTransaction().replace(R.id.content_main, fragment).commit();
        }

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }
}
