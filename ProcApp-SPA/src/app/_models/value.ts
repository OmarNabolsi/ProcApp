import { Photo } from './photo';

export interface Value {
    id: number;
    name: string;
    created: Date;
    lastUpdated: Date;
    photoUrl: string;
    description?: string;
    photos?: Photo[];
}
