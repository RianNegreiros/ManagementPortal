<template>
  <div class="btn-link">
    <button @click="visitRoute">
      <slot></slot>
    </button>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import { Prop } from "vue-property-decorator";

@Component({
  name: "MgButton",
  components: {},
})
export default class MgButton extends Vue {
  @Prop({ required: false, type: String })
  link?: string;

  visitRoute() {
    if (this.link) {
      this.$router.push(this.link);
    }
  }
}
</script>

<style scoped></style>
