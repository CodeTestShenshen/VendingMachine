export class RunningState {
    MachineSeriesNumber: string;
    FlavourCategories: FlavourCategories;
    CashStatus: CashStates;
    EftopsInCents: number;
}

export class Cash {
    cashType: string;
    unit: number;
    quantity: number;
    displayName: string;
}

export class CashStates {
    'c5': Cash;
    'c10': Cash;
    'c20': Cash;
    'c50': Cash;
    'Aud1': Cash;
    'Aud2': Cash;
    'Aud5': Cash;
    'Aud10': Cash;
    'Aud20': Cash;
}

export interface FlavourCategories {
    aaa: number;
    aaa1: number;
    aaa2: number;
    aaa3: number;
}