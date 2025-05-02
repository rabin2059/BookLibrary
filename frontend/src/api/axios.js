import axios from "axios";

const apiClient = axios.create({
  baseURL: "http://localhost:5202/api",
});

export default apiClient;
