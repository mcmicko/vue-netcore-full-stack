<template>
  <div class="book-wrapper">
    <p class="book-title">{{book.title}}</p>
    <p class="book-author">{{book.author}}</p>
    <p class="book-created">{{book.createdOn | humanize}}</p>
    <div @click="deleteBook(book.id)" class="deleteBtn">x</div>
  </div>
</template>

<script lang="ts">
import { Vue, Component, Prop } from "vue-property-decorator";
import IBook from "@/types/Book";
import BookService from "../service/book-service";

const bookService = new BookService();

@Component({
  name: "Book",
  components: {}
})
export default class Book extends Vue {
  @Prop({ required: true })
  book!: IBook;

  async deleteBook(id: number) {
    await bookService.deleteBook(id);
    this.$emit("deleted", id);
  }
}
</script>

<style lang="scss" scoped>
.book-wrapper {
  position: relative;
  margin: 0.8rem;
  padding: 0.4rem;
  border: 1px solid #555;
  border-radius: 20px;
  background: #e0e0e0;
  box-shadow: 0px 0px 4px #000000;

  .book-title {
    font-size: 1.2rem;
    font-weight: bold;
  }
  .book-author {
    color: #333;
  }
  .book-created {
    font-size: 0.9rem;
    color: #333;
  }
  .deleteBtn {
    color: red;
    position: absolute;
    right: 10px;
    top: 10px;
    cursor: pointer;
  }
}
</style>