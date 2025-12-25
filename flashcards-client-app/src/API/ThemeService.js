import axios from "axios";

export default class ThemeService {
    static async getAll(limit = 15, page = 1) {
        const response = await axios.get('https://localhost:7172/api/theme', {
            params: {
                limit: limit,
                page: page
            }
        });
        return response;
        
    }
    static async getById(id) {
        const response = await axios.get(`https://localhost:7172/api/theme/${id}`);
        return response.data;
    }   
    static async create(theme) {
        const response = await axios.post('https://localhost:7172/api/theme/', theme);
        return response.data;
    }
    static async delete(id) {
        const response = await axios.delete(`https://localhost:7172/api/theme/${id}`);
        return response.data;
    }
}