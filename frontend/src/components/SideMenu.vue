<template>
  <div class="side-menu-container">
    <router-link to="/">
      <img id="imgLogo" alt="logo" src="../assets/logo.png" />
    </router-link>
    <h1>Management Portal</h1>
    <custom-button
      id="menuInventory"
      is-full-width
      @button:click="goToRoute('/inventory')"
    >
      Inventory
    </custom-button>
    <custom-button
      id="menuCustomers"
      is-full-width
      @button:click="goToRoute('/customers')"
    >
      Manage Customers
    </custom-button>
    <custom-button
      id="menuInvoice"
      is-full-width
      @button:click="goToRoute('/invoice/new')"
    >
      New Invoice
    </custom-button>
    <custom-button
      id="menuOrders"
      is-full-width
      @button:click="goToRoute('/orders')"
    >
      Orders
    </custom-button>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import CustomButton from "@/components/CustomButton.vue";

@Component({
  name: "SideMenu",
  components: { CustomButton }
})
export default class SideMenu extends Vue {
  async goToRoute(route: string) {
    await this.$router.push(route);
  }
}
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

#imgLogo {
  width: 100%;
}

h1 {
  font-size: 1.2rem;
  margin: 1rem 0;
}
</style>
