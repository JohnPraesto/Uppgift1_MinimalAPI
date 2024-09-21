export interface APIResponse{
    isSuccess: boolean;
    result: object;
    statusCode: number;
    errorMessages: string[]    
}