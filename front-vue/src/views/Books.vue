<template>
  <div class="books-container">
    <h1>My Books</h1>
    <div v-if="myBooks.length">
      <Book @deleted="getAllBooks" :book="book" v-for="book in myBooks" :key="book.id" />
    </div>
  </div>
</template>

<script lang='ts'>
import { Component, Vue } from "vue-property-decorator";
import IBook from "../types/Book";
import Book from "../components/Book.vue";
import BookService from "../service/book-service";

const bookService = new BookService();

@Component({
  name: "MyBooks",
  components: { Book }
})
export default class MyBooks extends Vue {
  //data
  myBooks: IBook[] = [];
  //computed properties
  get bookCount() {
    return this.myBooks.length;
  }

  getAllBooks() {
    bookService
      .getAllBooks()
      .then(res => (this.myBooks = res))
      .catch(err => console.log(err));
  }

  created() {
    this.getAllBooks();
  }
  //watchers
}
</script>

<style lang="scss">
</style>