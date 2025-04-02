-- +goose NO TRANSACTION

-- +goose Up
-- +goose StatementBegin
CREATE INDEX CONCURRENTLY IX_document_reference_types_display_name_GIN
    ON document_reference_types using gin ("display_name" collate "und-x-icu" gin_trgm_ops) with (fastupdate = false);
-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
DROP INDEX CONCURRENTLY IX_document_reference_types_display_name_GIN;
-- +goose StatementEnd
