package hr.fer.oo.ednevnik.model;

/**
 * Created by luka0 on 20.1.2017..
 */
public class School {

    private Integer id;
    private String name;
    private Integer administratorId;

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

    public Integer getAdministratorId() {
        return administratorId;
    }

    public void setAdministratorId(Integer administratorId) {
        this.administratorId = administratorId;
    }
}
