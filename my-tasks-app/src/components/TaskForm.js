import React, { useState, useEffect } from "react";
import styles from "./TaskForm.module.css";

const initialState = {
  title: "",
  description: "",
  assignedUserId: 1,
  startDate: "",
  endDate: "",
  isCompleted: false,
};

const TaskForm = ({ onSubmit, selectedTask, onCancel }) => {
  const [task, setTask] = useState(initialState);
  const [errors, setErrors] = useState({});
  const [formError, setFormError] = useState(null);

  useEffect(() => {
    if (selectedTask) {
      setTask(selectedTask);
    }
  }, [selectedTask]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setTask({ ...task, [name]: value });
    // Clear error when user starts typing
    if (errors[name]) {
      setErrors(prev => ({ ...prev, [name]: null }));
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setErrors({});
    setFormError(null);

    try {
      await onSubmit(task);
      setTask(initialState);
    } catch (err) {
      if (err.response?.status === 400 && err.response.data?.errors) {
        // Transform backend errors into a more usable format
        const backendErrors = err.response.data.errors.reduce((acc, error) => {
          // Convert propertyName to camelCase to match React form field names
          const fieldName = error.propertyName.charAt(0).toLowerCase() + error.propertyName.slice(1);
          return { ...acc, [fieldName]: error.errorMessage };
        }, {});
        
        setErrors(backendErrors);
      } else {
        setFormError(err.message || "Something went wrong. Please try again.");
      }
    }
  };

  // Helper function to get error for a field
  const getFieldError = (fieldName) => errors[fieldName];

  return (
    <form className={styles.formContainer} onSubmit={handleSubmit}>
      <h3>{selectedTask ? "Edit Task" : "Add Task"}</h3>
      
      {formError && (
        <div className={styles.formError}>
          {formError}
        </div>
      )}

      <div className={styles.formGroup}>
        <label htmlFor="title">Title</label>
        <input
          id="title"
          name="title"
          value={task.title}
          onChange={handleChange}
          placeholder="Title"
          required
          className={getFieldError("title") ? styles.errorInput : ""}
        />
        {getFieldError("title") && (
          <span className={styles.fieldError}>{getFieldError("title")}</span>
        )}
      </div>

      <div className={styles.formGroup}>
        <label htmlFor="description">Description</label>
        <input
          id="description"
          name="description"
          value={task.description}
          onChange={handleChange}
          placeholder="Description"
          required
          className={getFieldError("description") ? styles.errorInput : ""}
        />
        {getFieldError("description") && (
          <span className={styles.fieldError}>{getFieldError("description")}</span>
        )}
      </div>

      <div className={styles.formGroup}>
        <label htmlFor="assignedUserId">Assigned User ID</label>
        <input
          id="assignedUserId"
          type="number"
          name="assignedUserId"
          value={task.assignedUserId}
          onChange={handleChange}
          placeholder="Assigned User ID"
          required
          className={getFieldError("assignedUserId") ? styles.errorInput : ""}
        />
        {getFieldError("assignedUserId") && (
          <span className={styles.fieldError}>{getFieldError("assignedUserId")}</span>
        )}
      </div>

      <div className={styles.formGroup}>
        <label htmlFor="startDate">Start Date</label>
        <input
          id="startDate"
          type="datetime-local"
          name="startDate"
          value={task.startDate}
          onChange={handleChange}
          required
          className={getFieldError("startDate") ? styles.errorInput : ""}
        />
        {getFieldError("startDate") && (
          <span className={styles.fieldError}>{getFieldError("startDate")}</span>
        )}
      </div>

      <div className={styles.formGroup}>
        <label htmlFor="endDate">End Date</label>
        <input
          id="endDate"
          type="datetime-local"
          name="endDate"
          value={task.endDate}
          onChange={handleChange}
          required
          className={getFieldError("endDate") ? styles.errorInput : ""}
        />
        {getFieldError("endDate") && (
          <span className={styles.fieldError}>{getFieldError("endDate")}</span>
        )}
      </div>

      <div className={styles.buttonGroup}>
        <button type="submit" className={styles.submitButton}>
          {selectedTask ? "Update" : "Create"}
        </button>
        <button type="button" onClick={onCancel} className={styles.cancelButton}>
          Cancel
        </button>
      </div>
    </form>
  );
};

export default TaskForm;