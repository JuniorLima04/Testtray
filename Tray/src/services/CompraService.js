import http from "../http-common";

class CompraService {
    getAll() {
        return http.get("/Compra");
    }

    create(Produto) {
        return http.post("/Compra", Produto);
    }

    update(id, data) {
        return http.put(`/Compra/${id}`, data);
      }

    delete(id) {
        return http.delete(`/Compra/${id}`);
    }
}

export default new CompraService();