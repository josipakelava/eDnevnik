package hr.fer.oo.ednevnik;

import java.util.Date;
import java.util.List;

import hr.fer.oo.ednevnik.model.Absence;
import hr.fer.oo.ednevnik.model.Cmn;
import hr.fer.oo.ednevnik.model.Grade;
import hr.fer.oo.ednevnik.model.Mark;
import hr.fer.oo.ednevnik.model.Note;
import hr.fer.oo.ednevnik.model.Student;
import hr.fer.oo.ednevnik.model.Subject;
import hr.fer.oo.ednevnik.model.Token;
import hr.fer.oo.ednevnik.model.User;
import retrofit2.Call;
import retrofit2.http.Field;
import retrofit2.http.FormUrlEncoded;
import retrofit2.http.GET;
import retrofit2.http.Header;
import retrofit2.http.POST;
import retrofit2.http.Path;

/**
 * Created by luka0 on 22.1.2017..
 */

public interface RestApi {

    @FormUrlEncoded
    @POST("api/Login")
    Call<Token> login(@Field("Email") String username, @Field("Password") String password, @Field("Uloga") String uloga);

    @FormUrlEncoded
    @POST("api/Profesor/AddMark")
    Call<Boolean> addMark(@Field("StudentId") String studentId, @Field("SubjectId") String subjectId, @Field("CategoryId") String categorId, @Field("Mark") String mark, @Field("Month") String month);

    @FormUrlEncoded
    @POST("api/Profesor/AddNote")
    Call<Boolean> addNote(@Field("StudentId") String studentId, @Field("SubjectId") String subjectId, @Field("Date") Date date, @Field("Note") String note);

    @FormUrlEncoded
    @POST("api/Profesor/AddAbsence")
    Call<Boolean> addAbsence(@Field("Studentid")String studentid, @Field("SubjectId")String subjectId, @Field("Date")Date date, @Field("Reason")String reason);

    @GET("api/Ucenik/Profil")
    Call<User> getProfile(@Header("Authorization") String token);

    @GET("api/Ucenik/Subjects")
    Call<List<Subject>> getSubjects(@Header("Authorization") String token);

    @GET("api/Ucenik/Subjects/{subjectId}/Marks")
    Call<List<Mark>> getMarks(@Header("Authorization") String token, @Path("subjectId") Integer subjectId);

    @GET("api/Ucenik/Subjects/{subjectId}/Notes")
    Call<List<Note>> getNotes(@Header("Authorization") String token, @Path("subjectId") Integer subjectId);

    @GET("api/Ucenik/Subject/{subjectId}/Cmn")
    Call<Cmn> getCmn(@Header("Authorization") String token, @Path("subjectId") Integer subjectId);

    @GET("api/Ucenik/Absences")
    Call<List<Absence>> getAbsences(@Header("Authorization") String token);

    @GET("api/Profesor/Profil")
    Call<User> getProfileProf(@Header("Authorization") String token);

    @GET("api/Profesor/Grades")
    Call<List<Grade>> getGrades(@Header("Authorization") String token);

    @GET("api/Profesor/MyGrade")
    Call<List<Student>> getMyGrade(@Header("Authorization") String token);

    @GET("api/Profesor/MyGrade/{studentId}/Subjects")
    Call<List<Subject>> getSubjectsForMyStudent(@Header("Authorization") String token, @Path("subjectId") Integer subjectId);

    @GET("api/Profesor/MyGrade/{studentId}/Subjects/{subjectId}/Cmn")
    Call<List<Cmn>> getCmnForMyStudent(@Header("Authorization") String token, @Path("studentId") Integer studentId, @Path("subjectId") Integer subjectId);

    @GET("api/Profesor/Grades/{gradeId}/Subjects")
    Call<List<Subject>> getSubjectsForGrade(@Header("Authorization") String token, @Path("gradeId") Integer gradeId);

    @GET("api/Profesor/Grades/{gradeId}/Subjects/{subjectId}/Students")
    Call<List<Student>> getStudentsForSubject(@Header("Authorization") String token, @Path("gradeId") Integer gradeId, @Path("subjectId") Integer subjectId);

    @GET("api/Profesor/Grades/{gradeId}/Subjects/{subjectId}/Students/{studentId}")
    Call<Cmn> getCmnForStudent(@Header("Authorization") String token, @Path("gradeId") Integer gradeId, @Path("subjectId") Integer subjectId, @Path("studentId") Integer studentId);

}
