package hr.fer.oo.ednevnik.adapters;

import android.content.Intent;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import java.util.List;

import hr.fer.oo.ednevnik.R;
import hr.fer.oo.ednevnik.main.StudentsActivity;
import hr.fer.oo.ednevnik.model.Subject;

public class MyTeacherSubjectRecyclerViewAdapter extends RecyclerView.Adapter<MyTeacherSubjectRecyclerViewAdapter.MyViewHolder> {

    private List<Subject> subjects;

    public class MyViewHolder extends RecyclerView.ViewHolder {
        public TextView name, id;
        public View mView;

        public MyViewHolder(View view) {
            super(view);
            mView = view;
            name = (TextView) view.findViewById(R.id.subject_content);
            id = (TextView) view.findViewById(R.id.subject_id);
        }
    }

    public MyTeacherSubjectRecyclerViewAdapter(List<Subject> subjects) {
        this.subjects = subjects;
    }

    @Override
    public MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View itemView = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.activity_subject_list, parent, false);

        return new MyViewHolder(itemView);
    }

    @Override
    public void onBindViewHolder(MyViewHolder holder, final int position) {
        Subject subject = subjects.get(position);
        holder.name.setText(subject.getName());
        holder.id.setText(subject.getId().toString());

        holder.mView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent i = new Intent(view.getContext(), StudentsActivity.class);
                i.putExtra("SUBJECT_ID", subjects.get(position).getId().toString());
                i.putExtra("SUBJECT_NAME", subjects.get(position).getName());
                view.getContext().startActivity(i);
            }
        });
    }

    @Override
    public int getItemCount() {
        return subjects.size();
    }
}