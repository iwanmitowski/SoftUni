import * as api from './api.js';

const endpoints = {
    'cars': '/data/cars',
};

export async function getAllData(){
    return api.get(endpoints.cars + `?sortBy=_createdOn%20desc`);
}

export async function getById(id){
    return api.get(endpoints.cars + `/${id}`);
}

export async function deleteData(id){
    return api.delete(endpoints.cars + `/${id}`);
}

export async function create(data){
    return api.post(endpoints.cars, data);
}

export async function edit(data){
    return api.put(endpoints.cars + `/${data.id}`, data);
}

export async function getMyData(userId){
    return api.get(endpoints.cars + `?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}