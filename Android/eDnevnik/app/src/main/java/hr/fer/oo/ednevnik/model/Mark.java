package hr.fer.oo.ednevnik.model;

import java.util.Date;

/**
 * Created by luka0 on 20.1.2017..
 */
public class Mark {

    private Integer id;
    private Date date;
    private Integer mark;
    private Integer categoryId;
    private Integer subjectId;
    private Integer studentId;

    public Mark(Integer id, Date date, Integer mark, Integer categoryId) {
        this.id = id;
        this.date = date;
        this.mark = mark;
        this.categoryId = categoryId;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }

    public Integer getMark() {
        return mark;
    }

    public void setMark(Integer mark) {
        this.mark = mark;
    }

    public Integer getCategoryId() {
        return categoryId;
    }

    public void setCategoryId(Integer categoryId) {
        this.categoryId = categoryId;
    }

    public Integer getSubjectId() {
        return subjectId;
    }

    public void setSubjectId(Integer subjectId) {
        this.subjectId = subjectId;
    }

    public Integer getStudentId() {
        return studentId;
    }

    public void setStudentId(Integer studentId) {
        this.studentId = studentId;
    }
}
