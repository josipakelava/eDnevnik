package hr.fer.oo.ednevnik.model;

/**
 * Created by luka0 on 19.1.2017..
 */

public class City {

    private Integer id;
    private String name;

    public City(String name) {
        this.name = name;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}
