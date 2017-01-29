package hr.fer.oo.ednevnik.model;

import java.util.List;

/**
 * Created by luka0 on 20.1.2017..
 */
public class Administrator extends User{

    private List<School> schools;

    public List<School> getSchools() {
        return schools;
    }

    public void setSchools(List<School> schools) {
        this.schools = schools;
    }
}
