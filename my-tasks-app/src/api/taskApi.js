// src/api/taskApi.js
import axios from "axios";

const BASE_URL = "http://localhost:5095/api/task"; // Update with your backend URL

export const getTasks = () => axios.get(BASE_URL);
export const createTask = (data) => axios.post(BASE_URL, data);
export const updateTask = (id, data) => axios.put(`${BASE_URL}/${id}`, data);
export const markComplete = (id) => axios.patch(`${BASE_URL}/${id}/complete`);
