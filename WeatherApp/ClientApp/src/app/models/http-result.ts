
export interface HttpResult<T> {
    isSuccess: boolean;
    errorMessage?: string;
    data?: T;
}