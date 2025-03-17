-- +goose Up
-- +goose StatementBegin

-- nolint:one-ddl-per-file
CREATE TABLE all_search_documents
(
    domain_id         TEXT      NOT NULL,
    id                TEXT      NOT NULL,
    template_Id       TEXT      NOT NULL,
    attributes_values JSONB     NOT NULL,
    concurrency_token TIMESTAMP NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'utc'),
    PRIMARY KEY (domain_id, id)
) PARTITION BY LIST (domain_id);

-- nolint:one-ddl-per-file
ALTER TABLE search_documents
DROP
CONSTRAINT search_documents_pkey;

-- nolint:one-ddl-per-file
ALTER TABLE search_documents
    ADD PRIMARY KEY (domain_id, id);

-- nolint:one-ddl-per-file
ALTER TABLE all_search_documents ATTACH PARTITION search_documents FOR VALUES IN ('8a3d776c-906a-4de2-9c20-1df638f1545b');
-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
DROP TABLE all_search_documents;
-- +goose StatementEnd
