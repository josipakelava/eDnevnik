package hr.fer.oo.ednevnik.model;

import java.util.Date;

/**
 * Created by luka0 on 20.1.2017..
 */
public class Professor extends User{

    private Date employmentOfDate;
    private Date employmenTofDate;
    private Integer schoolId;
    private Integer classTeacherId;

    public Date getEmploymentOfDate() {
        return employmentOfDate;
    }

    public void setEmploymentOfDate(Date employmentOfDate) {
        this.employmentOfDate = employmentOfDate;
    }

    public Date getEmploymenTofDate() {
        return employmenTofDate;
    }

    public void setEmploymenTofDate(Date employmenTofDate) {
        this.employmenTofDate = employmenTofDate;
    }

    public Integer getSchoolId() {
        return schoolId;
    }

    public void setSchoolId(Integer schoolId) {
        this.schoolId = schoolId;
    }

    public Integer getClassTeacherId() {
        return classTeacherId;
    }

    public void setClassTeacherId(Integer classTeacherId) {
        this.classTeacherId = classTeacherId;
    }
}
