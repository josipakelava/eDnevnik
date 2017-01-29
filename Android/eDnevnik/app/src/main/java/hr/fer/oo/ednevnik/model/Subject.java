package hr.fer.oo.ednevnik.model;

/**
 * Created by luka0 on 20.1.2017..
 */
public class Subject {

    private Integer id;
    private String name;

    public Subject(String name) {
        this.name = name;
    }

    public Subject(Integer id, String name) {
        this.id = id;
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
