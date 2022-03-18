import * as api from './api.js';

const endpoints = {
    'catalog': '/data/catalog',
};

export async function getAllData(){
    return api.get(endpoints.catalog);
}

export async function getMyData(id){
    return api.get(endpoints.catalog + `?where=_ownerId%3D%22${id}%22`);
}

export async function getDataById(id){
    return api.get(endpoints.catalog + `/${id}`);
}

export async function deleteData(id){
    return api.delete(endpoints.catalog + `/${id}`);
}

export async function createFurniture(data){
    return api.post(endpoints.catalog, data)
}

export async function editData(id, data) {
    return await api.put(endpoints.catalog + `/${id}`, data);
}
