package hr.fer.oo.ednevnik.adapters;

import android.content.Intent;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import java.util.List;

import hr.fer.oo.ednevnik.R;
import hr.fer.oo.ednevnik.main.MarksProfActivity;
import hr.fer.oo.ednevnik.model.Student;

public class MyTeacherStudentRecyclerViewAdapter extends RecyclerView.Adapter<MyTeacherStudentRecyclerViewAdapter.MyViewHolder> {

    private List<Student> students;

    public class MyViewHolder extends RecyclerView.ViewHolder {
        public TextView name, id;
        public View mView;

        public MyViewHolder(View view) {
            super(view);
            mView = view;
            name = (TextView) view.findViewById(R.id.student_content);
            id = (TextView) view.findViewById(R.id.student_id);
        }
    }


    public MyTeacherStudentRecyclerViewAdapter(List<Student> students) {
        this.students = students;
    }

    @Override
    public MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View itemView = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.activity_student_list, parent, false);

        return new MyViewHolder(itemView);
    }

    @Override
    public void onBindViewHolder(MyViewHolder holder, final int position) {
        final Student student = students.get(position);
        holder.name.setText(student.getFirstName()+" "+student.getLastName());
        holder.id.setText(student.getId().toString());

        holder.mView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent i = new Intent(view.getContext(), MarksProfActivity.class);
                i.putExtra("STUDENT_ID", students.get(position).getId().toString());
                view.getContext().startActivity(i);
            }
        });
    }

    @Override
    public int getItemCount() {
        return students.size();
    }
}