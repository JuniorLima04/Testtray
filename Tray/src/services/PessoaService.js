import http from "../http-common";

class PessoaService {
  getAll(params) {
    return http.get("/Pessoa", { params });
  }

  getById(id) {
    return http.get(`/Pessoa/${id}`);
  }

  create(data) {
    return http.post("/Pessoa", data);
  }

  update(id, data) {
    return http.put(`/Pessoa/${id}`, data);
  }

  delete(id) {
    return http.delete(`/Pessoa/${id}`);
  }

  patch(id, data) {
    return http.patch(`/Pessoa/${id}`, data);
  }

  getByEmail(email) {
    return http.get(`/Pessoa?email=${email}`);
  }

}

export default new PessoaService();
