<template>
  <div class="books-container">
    <h1>My Books</h1>
    <div v-if="myBooks.length">{{myBooks}}</div>
  </div>
</template>

<script lang='ts'>
import { Component, Vue } from "vue-property-decorator";
import IBook from "../types/Book";
import BookService from "../service/book-service";

const bookService = new BookService();

@Component({
  name: "MyBooks",
  components: {}
})
export default class MyBooks extends Vue {
  //data
  myBooks: IBook[] = [];
  //computed properties
  get bookCount() {
    return this.myBooks.length;
  }
  //props
  //methods
  //lifecycle books
  created() {
    bookService
      .getAllBooks()
      .then(res => (this.myBooks = res))
      .catch(err => console.log(err));
  }
  //watchers
}
</script>

<style lang="scss">
</style>