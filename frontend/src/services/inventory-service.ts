import axios from "axios";
import { IProductInventory } from "@/types/Product";

export class InventoryService {
  API_URL = process.env.VUE_APP_API_URL;

  public async getInventory(): Promise<IProductInventory[]> {
    const result = await axios.get(`${this.API_URL}/inventory/`);
    return result.data;
  }
}
