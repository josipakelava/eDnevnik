package hr.fer.oo.ednevnik.model;

import java.util.List;

/**
 * Created by luka0 on 26.1.2017..
 */
public class Cmn {

    private List<Category> categories;
    private List<Mark> marks;
    private List<Note> notes;

    public List<Category> getCategories() {
        return categories;
    }

    public void setCategories(List<Category> categories) {
        this.categories = categories;
    }

    public List<Mark> getMarks() {
        return marks;
    }

    public void setMarks(List<Mark> marks) {
        this.marks = marks;
    }

    public List<Note> getNotes() {
        return notes;
    }

    public void setNotes(List<Note> notes) {
        this.notes = notes;
    }
}
