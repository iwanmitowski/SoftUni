import * as api from './api.js';

const endpoints = {
    'pets': '/data/pets',
    'donation': '/data/donation',
};

export async function get(){
    return api.get(endpoints.pets + '?sortBy=_createdOn%20desc&distinct=name');
}

export async function getById(id){
    return api.get(endpoints.pets + `/${id}`);
}

export async function getMine(id){
    return api.get(endpoints.pets + `?where=_ownerId%3D%22${id}%22&sortBy=_createdOn%20desc`);
}

export async function create(pet){
    return api.post(endpoints.pets, pet);
}

export async function remove(id){
    return api.delete(endpoints.pets + `/${id}`);
}

export async function edit(pet, id){
    return api.put(endpoints.pets + `/${id}`, pet);
}

export async function donate(pet){
    return api.post(endpoints.donation, pet);
}

export async function getDonationCount(petId){
    return api.get(endpoints.donation + `?where=petId%3D%22${petId}%22&distinct=_ownerId&count`)
}

export async function isDonated(petId, userId){
    return api.get(endpoints.donation + `?where=petId%3D%22${petId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}