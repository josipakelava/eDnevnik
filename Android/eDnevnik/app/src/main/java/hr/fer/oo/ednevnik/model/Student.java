package hr.fer.oo.ednevnik.model;

/**
 * Created by luka0 on 20.1.2017..
 */
public class Student extends User{

    private Grade grade;

    public Grade getGrade() {
        return grade;
    }

    public void setGrade(Grade grade) {
        this.grade = grade;
    }

}
