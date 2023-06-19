<template>
  <modal>
    <template v-slot:header> Receive Shipment </template>
    <template v-slot:body>
      <label for="product">Product Received:</label>
      <select v-model="selectedProduct" class="shipmentItems" id="product">
        <option disabled value="">Please select one</option>
        <option v-for="item in inventory" :value="item" :key="item.product.id">
          {{ item.product.name }}
        </option>
      </select>
      <label for="qtyReceived">Quantity Received:</label>
      <input type="number" id="qtyReceived" v-model="qtyReceived" />
    </template>
    <template v-slot:footer>
      <side-menu-button
        type="button"
        @button:click="save"
        aria-label="save new shipment"
      >
        Save Received Shipment
      </side-menu-button>
      <side-menu-button
        type="button"
        @button:click="close"
        aria-label="Close modal"
      >
        Close
      </side-menu-button>
    </template>
  </modal>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import SideMenuButton from "@/components/SideMenuButton.vue";
import Modal from "@/components/modals/Modal.vue";
import { IProduct, IProductInventory } from "@/types/Product";
import { IShipment } from "@/types/Shipment";

@Component({
  name: "ShipmentModal",
  components: { SideMenuButton, Modal },
})
export default class ShipmentModal extends Vue {
  @Prop({ required: true, type: Array as () => IProductInventory[] })
  inventory!: IProductInventory[];

  selectedProduct: IProduct = {
    createdOn: new Date(),
    updatedOn: new Date(),
    id: 0,
    description: "",
    isTaxable: false,
    name: "",
    price: 0,
    isArchived: false,
  };

  qtyReceived = 0;

  close() {
    this.$emit("close");
  }

  save() {
    const shipment: IShipment = {
      productId: this.selectedProduct.id,
      adjustment: this.qtyReceived,
    };

    this.$emit("save:shipment", shipment);
  }
}
</script>

<style scoped></style>
