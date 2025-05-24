import React from "react";
import styles from "./TaskList.module.css";

const TaskList = ({ tasks, onEdit, onMarkComplete, onAddClick }) => {
  return (
    <div className={styles.tableContainer}>
      <table className={styles.table}>
        <thead>
          <tr>
            <th>Title</th>
            <th>Assigned User</th>
            <th>End Date</th>
            <th>Status</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {tasks.length === 0 ? (
            <tr>
              <td colSpan="5" className={styles.noTasksRow}>
                <div className={styles.noTasksContent}>
                  <div className={styles.noTasksIcon}>🗒️</div>
                  <div>No tasks found.</div>
                  <button
                    className={styles.addFirstTaskButton}
                    onClick={onAddClick}
                  >
                    ➕ Add your first task
                  </button>
                </div>
              </td>
            </tr>
          ) : (
            tasks.map((task) => (
              <tr key={task.id}>
                <td>{task.title}</td>
                <td>{task.assignedUserId}</td>
                <td>{new Date(task.endDate).toLocaleString()}</td>
                <td>{task.isCompleted ? "✅ Completed" : "❌ Pending"}</td>
                <td>
                  {!task.isCompleted && (
                    <button
                      className={styles.complete}
                      onClick={() => onMarkComplete(task.id)}
                    >
                      Mark Complete
                    </button>
                  )}
                  <button
                    className={styles.edit}
                    onClick={() => onEdit(task)}
                  >
                    Edit
                  </button>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
};

export default TaskList;
