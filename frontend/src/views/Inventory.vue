<template>
  <div class="inventory-container">
    <h1 id="inventoryTitle">Inventory Dashboard</h1>
    <hr />

    <table id="inventoryTable" class="table">
      <tr>
        <th>Item</th>
        <th>Quantity On-hand</th>
        <th>Unit Price</th>
        <th>Taxable</th>
        <th>Delete</th>
      </tr>

      <tr v-for="item in inventory" :key="item.id">
        <td>{{ item.product.name }}</td>
        <td>{{ item.quantityOnHand }}</td>
        <td>{{ item.product.price }}</td>
        <td>
          <span v-if="item.product.isTaxable">Yes</span>
          <span v-else>No</span>
        </td>
        <div>x</div>
      </tr>
    </table>
  </div>
</template>

<script lang="ts">
import { IProductInventory } from "@/types/Product";
import { Component, Vue } from "vue-property-decorator";

@Component({
  name: "Inventory",
  components: {},
})
export default class Inventory extends Vue {
  inventory: IProductInventory[] = [
    {
      id: 1,
      product: {
        id: 1,
        name: "Product 1",
        description: "Product 1 description",
        price: 1.99,
        createdOn: new Date(),
        updatedOn: new Date(),
        isTaxable: true,
        isArchived: false,
      },
      quantityOnHand: 10,
      idealQuantity: 20,
    },
    {
      id: 2,
      product: {
        id: 2,
        name: "Product 2",
        description: "Product 2 description",
        price: 2.99,
        createdOn: new Date(),
        updatedOn: new Date(),
        isTaxable: true,
        isArchived: false,
      },
      quantityOnHand: 20,
      idealQuantity: 30,
    },
    {
      id: 3,
      product: {
        id: 3,
        name: "Product 3",
        description: "Product 3 description",
        price: 3.99,
        createdOn: new Date(),
        updatedOn: new Date(),
        isTaxable: true,
        isArchived: false,
      },
      quantityOnHand: 30,
      idealQuantity: 40,
    },
    {
      id: 4,
      product: {
        id: 4,
        name: "Product 4",
        description: "Product 4 description",
        price: 4.99,
        createdOn: new Date(),
        updatedOn: new Date(),
        isTaxable: true,
        isArchived: false,
      },
      quantityOnHand: 40,
      idealQuantity: 50,
    },
    {
      id: 5,
      product: {
        id: 5,
        name: "Product 5",
        description: "Product 5 description",
        price: 5.99,
        createdOn: new Date(),
        updatedOn: new Date(),
        isTaxable: true,
        isArchived: false,
      },
      quantityOnHand: 50,
      idealQuantity: 60,
    },
  ];
}
</script>

<style scoped lang="scss"></style>
