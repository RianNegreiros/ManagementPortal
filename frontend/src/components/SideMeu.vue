<template>
  <div class="side-menu-container">
    <router-link to="/">
      <img id="logo" src="../assets/logo.png" alt="Logo" />
    </router-link>
    <h1>Management Portal</h1>
    <side-menu-button id="menuInventory" :link="'/inventory'" is-full-width>
      Inventory
    </side-menu-button>
    <side-menu-button id="menuCustomers" :link="'/customers'">
      Customers
    </side-menu-button>
    <side-menu-button id="menuInvoice" :link="'/invoice/new'">
      Invoice
    </side-menu-button>
    <side-menu-button id="menuOrders" :link="'/orders'">
      Orders
    </side-menu-button>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import SideMenuButton from "@/components/SideMenuButton.vue";

@Component({
  name: "SideMenu",
  components: { SideMenuButton },
})
export default class SideMenu extends Vue {}
</script>

<style scoped lang="scss">
@import "@/scss/global.scss";
.side-menu-container {
  background-color: #fcfcfc;
  height: 100vh;
  width: $menu-width;
  display: flex;
  flex-direction: column;
  padding: 0.8rem;
  box-shadow: 0 1px 1px rgba(0, 0, 0, 0.12), 0 1px 1px rgba(0, 0, 0, 0.24);
  box-sizing: border-box;
}
#logo {
  width: 100%;
}
h1 {
  font-size: 1.2rem;
  margin: 1rem 0;
}
</style>
