<template>
  <div class="btn-link">
    <button
      @click="onClick"
      :class="['side-menu-button', { 'full-width': isFullWidth }]"
      type="button"
    >
      <slot></slot>
    </button>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import { Prop } from "vue-property-decorator";

@Component({
  name: "SideMenuButton",
  components: {},
})
export default class SideMenuButton extends Vue {
  @Prop({ required: false, type: Boolean, default: false })
  isFullWidth?: boolean;

  onClick() {
    this.$emit("button:click");
  }
}
</script>

<style scoped lang="scss">
@import "@/scss/global.scss";

.side-menu-button {
  background: lighten($solar-blue, 10%);
  color: white;
  padding: 0.8rem;
  transition: background-color 0.5s;
  margin: 0.3rem 0.2rem;
  display: inline-block;
  cursor: pointer;
  font-size: 1rem;
  min-width: 100px;
  border: none;
  border-bottom: 2px solid darken($solar-blue, 20%);
  border-radius: 3px;

  &:hover {
    background: lighten($solar-blue, 20%);
    transition: background-color 0.5s;
  }

  &:disabled {
    background: lighten($solar-blue, 15%);
    border-bottom: 2px solid lighten($solar-blue, 20%);
  }

  &:active {
    background: $solar-yellow;
    border-bottom: 2px solid lighten($solar-yellow, 20%);
  }
}

.full-width {
  display: block;
  width: 100%;
}
</style>
