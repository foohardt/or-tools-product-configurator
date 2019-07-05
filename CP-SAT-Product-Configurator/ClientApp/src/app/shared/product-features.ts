
  export interface Engine {
      id: string;
      name: string;
      type: string;
  }

  export interface Gear {
      id: string;
      name: string;
      type: string;
  }

  export interface Wheel {
      id: string;
      name: string;
      type: string;
  }

  export interface Equipment {
      id: string;
      name: string;
      category: string;
  }

  export interface ProductFeatures {
      engines: Engine[];
      gears: Gear[];
      wheels: Wheel[];
      equipment: Equipment[];
  }



