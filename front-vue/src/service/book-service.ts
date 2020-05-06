import axios from 'axios'
import IBook from '@/types/Book';

export default class BookService {
  API_URL = process.env.VUE_APP_API_URL

  public async getAllBooks(): Promise<IBook[]> {
    let result = await axios.get(`${this.API_URL}/books/`)
    return result.data
  }

  public async addNewBook(book: IBook) {
    let result = await axios.post(`${this.API_URL}/books/`, book)
    return result.data
  }

  public async deleteBook(id: number) {
    let result = await axios.delete(`${this.API_URL}/books/${id}`)
    return result.data
  }
}